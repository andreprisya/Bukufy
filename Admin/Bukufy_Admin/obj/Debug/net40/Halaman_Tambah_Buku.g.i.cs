﻿#pragma checksum "..\..\..\Halaman_Tambah_Buku.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8DC3AA1E2A8DC0439AF4E9FBC5BD3CA04CA8E61A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Bukufy_Admin;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Bukufy_Admin {
    
    
    /// <summary>
    /// Halaman_Tambah_Buku
    /// </summary>
    public partial class Halaman_Tambah_Buku : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 86 "..\..\..\Halaman_Tambah_Buku.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnKembali;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Halaman_Tambah_Buku.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtJudul;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\Halaman_Tambah_Buku.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDeskripsi;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Halaman_Tambah_Buku.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPenerbit;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Halaman_Tambah_Buku.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPenulis;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\Halaman_Tambah_Buku.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtHarga;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\Halaman_Tambah_Buku.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStok;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\Halaman_Tambah_Buku.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGambar;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\Halaman_Tambah_Buku.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBrowse;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\..\Halaman_Tambah_Buku.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBatal;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\Halaman_Tambah_Buku.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTambah;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Bukufy_Admin;V1.0.0.0;component/halaman_tambah_buku.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Halaman_Tambah_Buku.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnKembali = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Halaman_Tambah_Buku.xaml"
            this.btnKembali.Click += new System.Windows.RoutedEventHandler(this.btnKembali_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtJudul = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtDeskripsi = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cmbPenerbit = ((System.Windows.Controls.ComboBox)(target));
            
            #line 116 "..\..\..\Halaman_Tambah_Buku.xaml"
            this.cmbPenerbit.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbPenerbit_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtPenulis = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtHarga = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtStok = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtGambar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btnBrowse = ((System.Windows.Controls.Button)(target));
            
            #line 166 "..\..\..\Halaman_Tambah_Buku.xaml"
            this.btnBrowse.Click += new System.Windows.RoutedEventHandler(this.btnBrowse_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnBatal = ((System.Windows.Controls.Button)(target));
            
            #line 177 "..\..\..\Halaman_Tambah_Buku.xaml"
            this.btnBatal.Click += new System.Windows.RoutedEventHandler(this.btnBatal_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnTambah = ((System.Windows.Controls.Button)(target));
            
            #line 181 "..\..\..\Halaman_Tambah_Buku.xaml"
            this.btnTambah.Click += new System.Windows.RoutedEventHandler(this.btnTambah_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

