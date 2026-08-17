namespace FabInspectionClient
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lotDataGridView = new System.Windows.Forms.DataGridView();
            this.lotIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processStepColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedAtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refreshButton = new System.Windows.Forms.Button();
            this.inspectionDataGridView = new System.Windows.Forms.DataGridView();
            this.resultIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.judgeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defectCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inspectedAtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analysisReasonTextBox = new System.Windows.Forms.TextBox();
            this.analysisRequestButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lotDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspectionDataGridView)).BeginInit();
            this.SuspendLayout();
            //
            // lotDataGridView
            //
            this.lotDataGridView.AllowUserToAddRows = false;
            this.lotDataGridView.AllowUserToDeleteRows = false;
            this.lotDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lotDataGridView.AutoGenerateColumns = false;
            this.lotDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lotDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lotIdColumn,
            this.productCodeColumn,
            this.processStepColumn,
            this.statusColumn,
            this.updatedAtColumn});
            this.lotDataGridView.Location = new System.Drawing.Point(12, 12);
            this.lotDataGridView.MultiSelect = false;
            this.lotDataGridView.Name = "lotDataGridView";
            this.lotDataGridView.ReadOnly = true;
            this.lotDataGridView.RowHeadersVisible = false;
            this.lotDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lotDataGridView.Size = new System.Drawing.Size(776, 300);
            this.lotDataGridView.TabIndex = 0;
            //
            // lotIdColumn
            //
            this.lotIdColumn.DataPropertyName = "LotId";
            this.lotIdColumn.HeaderText = "LOT ID";
            this.lotIdColumn.Name = "lotIdColumn";
            this.lotIdColumn.ReadOnly = true;
            //
            // productCodeColumn
            //
            this.productCodeColumn.DataPropertyName = "ProductCode";
            this.productCodeColumn.HeaderText = "Product Code";
            this.productCodeColumn.Name = "productCodeColumn";
            this.productCodeColumn.ReadOnly = true;
            //
            // processStepColumn
            //
            this.processStepColumn.DataPropertyName = "ProcessStep";
            this.processStepColumn.HeaderText = "Process Step";
            this.processStepColumn.Name = "processStepColumn";
            this.processStepColumn.ReadOnly = true;
            //
            // statusColumn
            //
            this.statusColumn.DataPropertyName = "Status";
            this.statusColumn.HeaderText = "Status";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            //
            // updatedAtColumn
            //
            this.updatedAtColumn.DataPropertyName = "UpdatedAt";
            this.updatedAtColumn.HeaderText = "Updated At";
            this.updatedAtColumn.Name = "updatedAtColumn";
            this.updatedAtColumn.ReadOnly = true;
            //
            // refreshButton
            //
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(688, 324);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 33);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "새로 고침";
            this.refreshButton.UseVisualStyleBackColor = true;
            //
            // inspectionDataGridView
            //
            this.inspectionDataGridView.AllowUserToAddRows = false;
            this.inspectionDataGridView.AllowUserToDeleteRows = false;
            this.inspectionDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inspectionDataGridView.AutoGenerateColumns = false;
            this.inspectionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inspectionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.resultIdColumn,
            this.equipmentIdColumn,
            this.judgeColumn,
            this.defectCountColumn,
            this.inspectedAtColumn});
            this.inspectionDataGridView.Location = new System.Drawing.Point(12, 369);
            this.inspectionDataGridView.MultiSelect = false;
            this.inspectionDataGridView.Name = "inspectionDataGridView";
            this.inspectionDataGridView.ReadOnly = true;
            this.inspectionDataGridView.RowHeadersVisible = false;
            this.inspectionDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inspectionDataGridView.Size = new System.Drawing.Size(776, 245);
            this.inspectionDataGridView.TabIndex = 2;
            //
            // resultIdColumn
            //
            this.resultIdColumn.DataPropertyName = "ResultId";
            this.resultIdColumn.HeaderText = "Result ID";
            this.resultIdColumn.Name = "resultIdColumn";
            this.resultIdColumn.ReadOnly = true;
            //
            // equipmentIdColumn
            //
            this.equipmentIdColumn.DataPropertyName = "EquipmentId";
            this.equipmentIdColumn.HeaderText = "Equipment ID";
            this.equipmentIdColumn.Name = "equipmentIdColumn";
            this.equipmentIdColumn.ReadOnly = true;
            //
            // judgeColumn
            //
            this.judgeColumn.DataPropertyName = "Judge";
            this.judgeColumn.HeaderText = "Judge";
            this.judgeColumn.Name = "judgeColumn";
            this.judgeColumn.ReadOnly = true;
            //
            // defectCountColumn
            //
            this.defectCountColumn.DataPropertyName = "DefectCount";
            this.defectCountColumn.HeaderText = "Defect Count";
            this.defectCountColumn.Name = "defectCountColumn";
            this.defectCountColumn.ReadOnly = true;
            //
            // inspectedAtColumn
            //
            this.inspectedAtColumn.DataPropertyName = "InspectedAt";
            this.inspectedAtColumn.HeaderText = "Inspected At";
            this.inspectedAtColumn.Name = "inspectedAtColumn";
            this.inspectedAtColumn.ReadOnly = true;
            //
            // analysisReasonTextBox
            //
            this.analysisReasonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisReasonTextBox.Location = new System.Drawing.Point(12, 626);
            this.analysisReasonTextBox.MaxLength = 500;
            this.analysisReasonTextBox.Multiline = true;
            this.analysisReasonTextBox.Name = "analysisReasonTextBox";
            this.analysisReasonTextBox.Size = new System.Drawing.Size(660, 56);
            this.analysisReasonTextBox.TabIndex = 3;
            //
            // analysisRequestButton
            //
            this.analysisRequestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisRequestButton.Location = new System.Drawing.Point(688, 638);
            this.analysisRequestButton.Name = "analysisRequestButton";
            this.analysisRequestButton.Size = new System.Drawing.Size(100, 33);
            this.analysisRequestButton.TabIndex = 4;
            this.analysisRequestButton.Text = "분석 요청";
            this.analysisRequestButton.UseVisualStyleBackColor = true;
            //
            // Form1
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 695);
            this.Controls.Add(this.analysisRequestButton);
            this.Controls.Add(this.analysisReasonTextBox);
            this.Controls.Add(this.inspectionDataGridView);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.lotDataGridView);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Text = "LOT 목록";
            ((System.ComponentModel.ISupportInitialize)(this.lotDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspectionDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView lotDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn processStepColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtColumn;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.DataGridView inspectionDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn judgeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn defectCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inspectedAtColumn;
        private System.Windows.Forms.TextBox analysisReasonTextBox;
        private System.Windows.Forms.Button analysisRequestButton;
    }
}
