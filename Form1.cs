using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FabInspectionClient
{
    public partial class Form1 : Form
    {
        private const string ApiBaseUrl = "http://localhost:8080";
        private static readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = new Uri(ApiBaseUrl)
        };
        private int inspectionRequestVersion;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            refreshButton.Click += RefreshButton_Click;
            lotDataGridView.CellClick += LotDataGridView_CellClick;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadLotsAsync();
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            await LoadLotsAsync();
        }

        private async Task LoadLotsAsync()
        {
            refreshButton.Enabled = false;
            inspectionRequestVersion++;
            inspectionDataGridView.DataSource = new List<InspectionDto>();

            try
            {
                using (HttpResponseMessage response = await HttpClient.GetAsync("/api/lots"))
                {
                    response.EnsureSuccessStatusCode();

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var serializer = new DataContractJsonSerializer(typeof(List<LotDto>));
                        var lots = serializer.ReadObject(responseStream) as List<LotDto>;
                        lotDataGridView.DataSource = lots ?? new List<LotDto>();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "LOT 목록을 조회하지 못했습니다.\n" + ex.Message,
                    "조회 오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                refreshButton.Enabled = true;
            }
        }

        private async void LotDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var lot = lotDataGridView.Rows[e.RowIndex].DataBoundItem as LotDto;
            if (lot == null || string.IsNullOrWhiteSpace(lot.LotId))
            {
                return;
            }

            await LoadInspectionsAsync(lot.LotId);
        }

        private async Task LoadInspectionsAsync(string lotId)
        {
            int requestVersion = ++inspectionRequestVersion;
            inspectionDataGridView.DataSource = new List<InspectionDto>();

            try
            {
                using (HttpResponseMessage response = await HttpClient.GetAsync("/api/lots/" + Uri.EscapeDataString(lotId) + "/inspections"))
                {
                    response.EnsureSuccessStatusCode();

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var serializer = new DataContractJsonSerializer(typeof(List<InspectionDto>));
                        var inspections = serializer.ReadObject(responseStream) as List<InspectionDto>;

                        if (requestVersion == inspectionRequestVersion)
                        {
                            inspectionDataGridView.DataSource = inspections ?? new List<InspectionDto>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (requestVersion == inspectionRequestVersion)
                {
                    inspectionDataGridView.DataSource = new List<InspectionDto>();
                    MessageBox.Show(
                        "검사 결과를 조회하지 못했습니다.\n" + ex.Message,
                        "조회 오류",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        [DataContract]
        private sealed class LotDto
        {
            [DataMember(Name = "lotId")]
            public string LotId { get; set; }

            [DataMember(Name = "productCode")]
            public string ProductCode { get; set; }

            [DataMember(Name = "processStep")]
            public string ProcessStep { get; set; }

            [DataMember(Name = "status")]
            public string Status { get; set; }

            [DataMember(Name = "updatedAt")]
            public string UpdatedAt { get; set; }
        }

        [DataContract]
        private sealed class InspectionDto
        {
            [DataMember(Name = "resultId")]
            public int ResultId { get; set; }

            [DataMember(Name = "lotId")]
            public string LotId { get; set; }

            [DataMember(Name = "equipmentId")]
            public string EquipmentId { get; set; }

            [DataMember(Name = "judge")]
            public string Judge { get; set; }

            [DataMember(Name = "defectCount")]
            public int DefectCount { get; set; }

            [DataMember(Name = "inspectedAt")]
            public string InspectedAt { get; set; }
        }
    }
}
