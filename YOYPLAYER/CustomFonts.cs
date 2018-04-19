
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace YOYPLAYER
{
    public static class CustomFonts
    {
        static PrivateFontCollection pfc = new PrivateFontCollection();
        static PrivateFontCollection pfc_Reg = new PrivateFontCollection();
        public static Font GetMontserrat_Bold(float argSize )
        {
            return new Font(pfc.Families[0], argSize);

        }

        public static Font GetMontserrat_Medium(float argSize )
        {
            return new Font(pfc.Families[1], argSize);

        }

        public static Font GetMontserrat_Regular(float argSize)
        {
            return new Font(pfc_Reg.Families[0], argSize);
        }


        public static void LoadFonts()
        {
            //PrivateFontCollection pfc = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = Properties.Resources.Montserrat_Bold.Length;
            byte[] fontdata = Properties.Resources.Montserrat_Bold;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
            

            fontLength = 0; fontdata = null;
            fontLength = Properties.Resources.Montserrat_Medium.Length;
            fontdata = Properties.Resources.Montserrat_Medium;

            System.IntPtr data2 = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data2, fontLength);
            pfc.AddMemoryFont(data2, fontLength);


            fontLength = 0; fontdata = null;
            fontLength = Properties.Resources.Montserrat_Regular.Length;
            fontdata = Properties.Resources.Montserrat_Regular;


            System.IntPtr data3 = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data3, fontLength);
            pfc_Reg.AddMemoryFont(data3, fontLength);
            
        }


    }
}
