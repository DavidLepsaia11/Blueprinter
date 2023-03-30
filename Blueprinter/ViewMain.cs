using Blueprinter.Presentation;

namespace Blueprinter
{
    public partial class ViewMain : Form, IViewMain
    {
        public ViewMain()
        {
            InitializeComponent();
        }

        private IViewMainPresenter _presenter;

        public IViewMainPresenter Presenter 
        { 
            get =>  _presenter; 
            set 
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        private void blueprinterManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.RunBlueprintManager();
        }
    }
}