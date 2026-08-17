using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
        private string selectedLotId;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            refreshButton.Click += RefreshButton_Click;
            demoDataButton.Click += DemoDataButton_Click;
            lotDataGridView.CellClick += LotDataGridView_CellClick;
            analysisRequestButton.Click += AnalysisRequestButton_Click;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadLotsAsync();
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            await LoadLotsAsync();
        }

        private async void DemoDataButton_Click(object sender, EventArgs e)
        {
            await CreateDemoInspectionLotAsync();
        }

        private async Task CreateDemoInspectionLotAsync()
        {
            demoDataButton.Enabled = false;

            try
            {
                using (HttpResponseMessage response = await HttpClient.PostAsync("/api/demo/inspection-lots", null))
                {
                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                        {
                            var serializer = new DataContractJsonSerializer(typeof(DemoInspectionLotResponseDto));
                            var result = serializer.ReadObject(responseStream) as DemoInspectionLotResponseDto;

                            if (result == null || string.IsNullOrWhiteSpace(result.LotId))
                            {
                                throw new InvalidDataException("데모 LOT 생성 응답에 lotId가 없습니다.");
                            }

                            MessageBox.Show(
                                "데모 LOT이 생성되었습니다.\n" + result.LotId,
                                "데모 데이터 생성",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }

                        await LoadLotsAsync();
                        return;
                    }

                    string errorMessage = await ReadErrorMessageAsync(response);
                    MessageBox.Show(errorMessage, "데모 데이터 생성 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "데모 데이터를 생성하지 못했습니다.\n" + ex.Message,
                    "데모 데이터 생성 오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                demoDataButton.Enabled = true;
            }
        }

        private async Task LoadLotsAsync()
        {
            refreshButton.Enabled = false;
            inspectionRequestVersion++;
            selectedLotId = null;
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

            selectedLotId = lot.LotId;
            await LoadInspectionsAsync(lot.LotId);
        }

        private async void AnalysisRequestButton_Click(object sender, EventArgs e)
        {
            string reason = analysisReasonTextBox.Text;

            if (string.IsNullOrWhiteSpace(selectedLotId))
            {
                MessageBox.Show("분석 요청할 LOT을 선택하세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("분석 사유를 입력하세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (reason.Length > 500)
            {
                MessageBox.Show("분석 사유는 500자 이내로 입력하세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            await RequestAnalysisAsync(selectedLotId, reason);
        }

        private async Task RequestAnalysisAsync(string lotId, string reason)
        {
            analysisRequestButton.Enabled = false;

            try
            {
                string requestJson = SerializeAnalysisTaskRequest(new AnalysisTaskRequestDto { Reason = reason });

                using (var content = new StringContent(requestJson, Encoding.UTF8, "application/json"))
                using (HttpResponseMessage response = await HttpClient.PostAsync("/api/lots/" + Uri.EscapeDataString(lotId) + "/analysis-tasks", content))
                {
                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        MessageBox.Show("분석 요청이 등록되었습니다.", "분석 요청", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        analysisReasonTextBox.Clear();
                        await LoadLotsAsync();
                        return;
                    }

                    string errorMessage = await ReadErrorMessageAsync(response);
                    MessageBox.Show(errorMessage, "분석 요청 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "분석 요청을 등록하지 못했습니다.\n" + ex.Message,
                    "분석 요청 오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                analysisRequestButton.Enabled = true;
            }
        }

        private static string SerializeAnalysisTaskRequest(AnalysisTaskRequestDto request)
        {
            var serializer = new DataContractJsonSerializer(typeof(AnalysisTaskRequestDto));

            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, request);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        private static async Task<string> ReadErrorMessageAsync(HttpResponseMessage response)
        {
            try
            {
                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var serializer = new DataContractJsonSerializer(typeof(ApiErrorResponseDto));
                    var error = serializer.ReadObject(responseStream) as ApiErrorResponseDto;

                    if (error != null && !string.IsNullOrWhiteSpace(error.Message))
                    {
                        return error.Message;
                    }
                }
            }
            catch (Exception)
            {
            }

            return "HTTP " + (int)response.StatusCode + " " + response.ReasonPhrase;
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

        [DataContract]
        private sealed class AnalysisTaskRequestDto
        {
            [DataMember(Name = "reason")]
            public string Reason { get; set; }
        }

        [DataContract]
        private sealed class ApiErrorResponseDto
        {
            [DataMember(Name = "message")]
            public string Message { get; set; }
        }

        [DataContract]
        private sealed class DemoInspectionLotResponseDto
        {
            [DataMember(Name = "lotId")]
            public string LotId { get; set; }
        }
    }
}
