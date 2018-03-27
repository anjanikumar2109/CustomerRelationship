﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer;
using FactoryLayer;

namespace PresentationLayer
{
    public partial class CustomerForm : Form
    {
        private CustomerBase customer;

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void SetCustomer()
        {
            customer.CustomerName = txtCustomerName.Text;
            customer.PhoneNumber = txtCustomerPhone.Text;
            customer.Address = txtCustomerAddress.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            customer = FactoryUnity<CustomerBase>.Create(cmbCustomerType.Text);
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                var compare = new Compare<int>();
                var outVar = compare["A"];
                compare.IsEqual(1, 2);
                SetCustomer();
                customer.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }

    class Compare<T>
    {
        public bool IsEqual(T i, T j)
        {
            return i.Equals(j);
        }

        public string this[string input] {
            get { return input; }
        }
    }
}