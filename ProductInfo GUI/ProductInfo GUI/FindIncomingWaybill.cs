using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductInfo_UI
{
    public partial class FindIncomingWaybill : Form
    {
        public FindIncomingWaybill()
        {
            InitializeComponent();
        }

        public event WaybillIDSelectedHandler evtWaybillIDSelected;
        public WBIDSelectedEventArgs eWBIDSelected = null;
        public delegate void WaybillIDSelectedHandler
            (FindIncomingWaybill frmFindIncomingWaybill, WBIDSelectedEventArgs eWBIDSelected);

        private void FindIncomingWaybill_Load(object sender, EventArgs e)
        {
        }

        private void btnSelectWaybill_ID_Click(object sender, EventArgs e)
        {
            //TODO: select one chosen waybill ID from listview
            //and assign to eWBIDSelected.Waybill_ID instead of 0
            //raise Waybill_ID selected event
            eWBIDSelected.Waybill_ID = 0;
            evtWaybillIDSelected(this, eWBIDSelected);
        }
    }

    public class WBIDSelectedEventArgs : EventArgs
    {
        private int _Waybill_ID;
        public int Waybill_ID
        {
            set
            {
                this._Waybill_ID = value;
            }
            get
            {
                return this._Waybill_ID;
            }
        }
    }
}
