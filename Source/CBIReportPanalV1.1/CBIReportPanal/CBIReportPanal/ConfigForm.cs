﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CBIReportPanal
{
    public partial class ConfigForm : Form
    {
        public ConfigForm(Form form)
        {
            InitializeComponent();
            this.MdiParent = form;
        }
    }
}
