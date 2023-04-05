using Blueprinter.Core;
using Blueprinter.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blueprinter
{
    public partial class ViewBlueprintManager : Form, IViewBlueprintManager
    {
        private IViewBlueprintManagerPresenter _presenter;
        private readonly BindingSource _data = new BindingSource();
        public IViewBlueprintManagerPresenter Presenter
        {
            get => _presenter;

            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }
        public ViewBlueprintManager()
        {
            InitializeComponent();
        }

        public IEnumerable<BlueprintInfo> Blueprints
        { 
            get => _data.List.Cast<BlueprintInfo>();
            set 
            {
                _data.DataSource = value.ToList();
            }

        }


        public void Run()
        {
            var nameBinding = new Binding("Text", _data, "Name");
            nameBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
           ShowDialog();    
        }
    }
}
