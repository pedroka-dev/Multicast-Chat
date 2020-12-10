namespace MulticastChat
{
    partial class FormMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonJoin = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelMessageChat = new System.Windows.Forms.Label();
            this.listBoxMessageChat = new System.Windows.Forms.ListBox();
            this.labelNewMessage = new System.Windows.Forms.Label();
            this.textBoxNewMessage = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(9, 13);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(83, 17);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "User Name:";
            this.labelUserName.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(102, 10);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(311, 22);
            this.textBoxUserName.TabIndex = 1;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(23, 47);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(97, 17);
            this.labelAddress.TabIndex = 2;
            this.labelAddress.Text = "Chat Address:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(126, 47);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(153, 22);
            this.textBoxAddress.TabIndex = 2;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(49, 82);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(71, 17);
            this.labelPort.TabIndex = 4;
            this.labelPort.Text = "Chat Port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(126, 82);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(153, 22);
            this.textBoxPort.TabIndex = 3;
            // 
            // buttonJoin
            // 
            this.buttonJoin.Location = new System.Drawing.Point(300, 46);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(113, 23);
            this.buttonJoin.TabIndex = 4;
            this.buttonJoin.Text = "Join Chat";
            this.buttonJoin.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(300, 82);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(113, 23);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit Chat";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // labelMessageChat
            // 
            this.labelMessageChat.AutoSize = true;
            this.labelMessageChat.Location = new System.Drawing.Point(12, 122);
            this.labelMessageChat.Name = "labelMessageChat";
            this.labelMessageChat.Size = new System.Drawing.Size(100, 17);
            this.labelMessageChat.TabIndex = 8;
            this.labelMessageChat.Text = "Message chat:";
            // 
            // listBoxMessageChat
            // 
            this.listBoxMessageChat.FormattingEnabled = true;
            this.listBoxMessageChat.ItemHeight = 16;
            this.listBoxMessageChat.Items.AddRange(new object[] {
            " "});
            this.listBoxMessageChat.Location = new System.Drawing.Point(15, 142);
            this.listBoxMessageChat.Name = "listBoxMessageChat";
            this.listBoxMessageChat.Size = new System.Drawing.Size(398, 196);
            this.listBoxMessageChat.TabIndex = 6;
            this.listBoxMessageChat.SelectedIndexChanged += new System.EventHandler(this.listBoxChat_SelectedIndexChanged);
            // 
            // labelNewMessage
            // 
            this.labelNewMessage.AutoSize = true;
            this.labelNewMessage.Location = new System.Drawing.Point(9, 351);
            this.labelNewMessage.Name = "labelNewMessage";
            this.labelNewMessage.Size = new System.Drawing.Size(100, 17);
            this.labelNewMessage.TabIndex = 10;
            this.labelNewMessage.Text = "New message:";
            // 
            // textBoxNewMessage
            // 
            this.textBoxNewMessage.Location = new System.Drawing.Point(12, 371);
            this.textBoxNewMessage.Name = "textBoxNewMessage";
            this.textBoxNewMessage.Size = new System.Drawing.Size(314, 22);
            this.textBoxNewMessage.TabIndex = 7;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(346, 371);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(67, 23);
            this.buttonSend.TabIndex = 8;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 407);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxNewMessage);
            this.Controls.Add(this.labelNewMessage);
            this.Controls.Add(this.listBoxMessageChat);
            this.Controls.Add(this.labelMessageChat);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonJoin);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelUserName);
            this.Name = "FormMain";
            this.Text = "Multicast Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonJoin;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelMessageChat;
        private System.Windows.Forms.Label labelNewMessage;
        private System.Windows.Forms.TextBox textBoxNewMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ListBox listBoxMessageChat;
    }
}

