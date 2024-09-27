
namespace MonitoramentoTempoOcioso.Forms
{
    partial class SyncForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pgbSync = new System.Windows.Forms.ProgressBar();
            this.lblEventsToSync = new System.Windows.Forms.Label();
            this.lblSyncedWithSuccess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgbSync
            // 
            this.pgbSync.Location = new System.Drawing.Point(12, 51);
            this.pgbSync.Name = "pgbSync";
            this.pgbSync.Size = new System.Drawing.Size(343, 23);
            this.pgbSync.TabIndex = 0;
            // 
            // lblEventsToSync
            // 
            this.lblEventsToSync.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEventsToSync.Location = new System.Drawing.Point(0, 0);
            this.lblEventsToSync.Name = "lblEventsToSync";
            this.lblEventsToSync.Size = new System.Drawing.Size(367, 24);
            this.lblEventsToSync.TabIndex = 1;
            this.lblEventsToSync.Text = "Pendente: ";
            this.lblEventsToSync.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSyncedWithSuccess
            // 
            this.lblSyncedWithSuccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSyncedWithSuccess.Location = new System.Drawing.Point(0, 24);
            this.lblSyncedWithSuccess.Name = "lblSyncedWithSuccess";
            this.lblSyncedWithSuccess.Size = new System.Drawing.Size(367, 24);
            this.lblSyncedWithSuccess.TabIndex = 2;
            this.lblSyncedWithSuccess.Text = "Integrado: ";
            this.lblSyncedWithSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 79);
            this.Controls.Add(this.lblSyncedWithSuccess);
            this.Controls.Add(this.lblEventsToSync);
            this.Controls.Add(this.pgbSync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SyncForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sincronizando...";
            this.Load += new System.EventHandler(this.SyncForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbSync;
        private System.Windows.Forms.Label lblEventsToSync;
        private System.Windows.Forms.Label lblSyncedWithSuccess;
    }
}