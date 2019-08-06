using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorConverter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* MVP architechture, first create the model, view and presenter - then let the presenter know of the view */
            Model theModel = new Model();
            Presenter thePresenter = new Presenter(theModel);
            View theView = new View(thePresenter);

            thePresenter.SetView(theView);

            Application.Run(theView as Form);
        }
    }
}
