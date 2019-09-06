using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BinaryConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Enter Paths to begin";
            label1.Update();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Converting file...";
            label1.Update();
            string file = textBox1.Text;
            string sbet = textBox2.Text;

            if (!Directory.Exists(file))
            {
                try
                {
                    Directory.CreateDirectory(file);
                }
                catch (Exception ads)
                {
                    MessageBox.Show(ads.Message);
                }
            }



            SBETstruct rec = new SBETstruct();
            vrms rec1 = new vrms();
            int cnt = 1;
            FileInfo a = new FileInfo(sbet);
            string value = "SBET " + a.Name + " CONVERTED DATA:";

            file += "\\Converted2-" + a.Name + ".txt";
            try
            {
                int pos = 0;
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine(value);
                    sw.WriteLine("_____________________");

                    var arr = File.ReadAllBytes(sbet);
                    for(int ind = 0; ind < arr.Length-135; ind = ind + 136)
                    {
                        rec.time = BitConverter.ToDouble(arr, ind);
                        ind += 8;
                        string time = "Time: " + rec.time.ToString();
                        sw.WriteLine(time);
                        pos += sizeof(double);

                        rec.lat = BitConverter.ToDouble(arr, ind);
                        ind += 8;
                        string lat = "Latitude: " + rec.lat.ToString();
                        sw.WriteLine(lat);
                        pos += sizeof(double);

                        rec.lon = BitConverter.ToDouble(arr, ind);
                        ind += 8;
                        string lon = "Longitude: " + rec.lon.ToString();
                        sw.WriteLine(lon);
                        pos += sizeof(double);

                        ind += (8 * 14);

                        
                    }

                    /*using (BinaryReader b = new BinaryReader(File.Open(sbet, FileMode.Open)))
                    {
                        int pos = 0;
                        var len = b.BaseStream.Length / sizeof(double);
                        try
                        {
                            for (var i = 0; i < len; i++)
                            {
                                string count = cnt.ToString() + ".";
                                sw.WriteLine(Environment.NewLine);
                                sw.WriteLine(count);
                                cnt++;

                                if (checkBox1.Checked)
                                {
                                    rec1.time = b.ReadDouble();
                                    string time = "Time: " + rec1.time.ToString();
                                    sw.WriteLine(time);
                                    pos += sizeof(double);

                                    rec1.lat = b.ReadDouble();
                                    string lat = "Latitude: " + rec1.lat.ToString();
                                    sw.WriteLine(lat);
                                    pos += sizeof(double);

                                    rec1.lon = b.ReadDouble();
                                    string lon = "Longitude: " + rec1.lon.ToString();
                                    sw.WriteLine(lon);
                                    pos += sizeof(double);

                                    rec1.alt = b.ReadDouble();
                                    string alt = "Altitude: " + rec1.alt.ToString();
                                    sw.WriteLine(alt);
                                    pos += sizeof(double);

                                    rec1.xvel = b.ReadDouble();
                                    string xvel = "X-velocity: " + rec1.xvel.ToString();
                                    sw.WriteLine(xvel);
                                    pos += sizeof(double);

                                    rec1.yvel = b.ReadDouble();
                                    string yvel = "Y-velocity: " + rec1.yvel.ToString();
                                    sw.WriteLine(yvel);
                                    pos += sizeof(double);

                                    rec1.zvel = b.ReadDouble();
                                    string zvel = "Z-velocity: " + rec1.zvel.ToString();
                                    sw.WriteLine(zvel);
                                    pos += sizeof(double);

                                    rec1.roll = b.ReadDouble();
                                    string roll = "Roll: " + rec1.roll.ToString();
                                    sw.WriteLine(roll);
                                    pos += sizeof(double);

                                    rec1.pitch = b.ReadDouble();
                                    string pitch = "Pitch: " + rec1.pitch.ToString();
                                    sw.WriteLine(pitch);
                                    pos += sizeof(double);

                                    rec1.heading = b.ReadDouble();
                                    string heading = "Platform Heading: " + rec1.heading.ToString();
                                    sw.WriteLine(heading);
                                    pos += sizeof(double);

                                }
                                else
                                {
                                    rec.time = b.ReadDouble();
                                    string time = "Time: " + rec.time.ToString();
                                    sw.WriteLine(time);
                                    pos += sizeof(double);

                                    rec.lat = b.ReadDouble();
                                    string lat = "Latitude: " + rec.lat.ToString();
                                    sw.WriteLine(lat);
                                    pos += sizeof(double);

                                    rec.lon = b.ReadDouble();
                                    string lon = "Longitude: " + rec.lon.ToString();
                                    sw.WriteLine(lon);
                                    pos += sizeof(double);

                                    rec.alt = b.ReadDouble();
                                    string alt = "Altitude: " + rec.alt.ToString();
                                    sw.WriteLine(alt);
                                    pos += sizeof(double);

                                    rec.xvel = b.ReadDouble();
                                    string xvel = "X-velocity: " + rec.xvel.ToString();
                                    sw.WriteLine(xvel);
                                    pos += sizeof(double);

                                    rec.yvel = b.ReadDouble();
                                    string yvel = "Y-velocity: " + rec.yvel.ToString();
                                    sw.WriteLine(yvel);
                                    pos += sizeof(double);

                                    rec.zvel = b.ReadDouble();
                                    string zvel = "Z-velocity: " + rec.zvel.ToString();
                                    sw.WriteLine(zvel);
                                    pos += sizeof(double);

                                    rec.roll = b.ReadDouble();
                                    string roll = "Roll: " + rec.roll.ToString();
                                    sw.WriteLine(roll);
                                    pos += sizeof(double);

                                    rec.pitch = b.ReadDouble();
                                    string pitch = "Pitch: " + rec.pitch.ToString();
                                    sw.WriteLine(pitch);
                                    pos += sizeof(double);

                                    rec.heading = b.ReadDouble();
                                    string heading = "Platform Heading: " + rec.heading.ToString();
                                    sw.WriteLine(heading);
                                    pos += sizeof(double);

                                    rec.wander = b.ReadDouble();
                                    string wander = "Wander Angle: " + rec.wander.ToString();
                                    sw.WriteLine(wander);
                                    pos += sizeof(double);

                                    rec.xacc = b.ReadDouble();
                                    string xacc = "X-acceleration: " + rec.xacc.ToString();
                                    sw.WriteLine(xacc);
                                    pos += sizeof(double);

                                    rec.yacc = b.ReadDouble();
                                    string yacc = "Y-acceleration: " + rec.yacc.ToString();
                                    sw.WriteLine(yacc);
                                    pos += sizeof(double);

                                    rec.zacc = b.ReadDouble();
                                    string zacc = "Z-acceleration: " + rec.zacc.ToString();
                                    sw.WriteLine(zacc);
                                    pos += sizeof(double);

                                    rec.xang = b.ReadDouble();
                                    string xang = "X-angular rate: " + rec.xang.ToString();
                                    sw.WriteLine(xang);
                                    pos += sizeof(double);

                                    rec.yang = b.ReadDouble();
                                    string yang = "Y-angular rate: " + rec.yang.ToString();
                                    sw.WriteLine(yang);
                                    pos += sizeof(double);

                                    rec.zang = b.ReadDouble();
                                    string zang = "Z-angular rate: " + rec.zang.ToString();
                                    sw.WriteLine(zang);
                                    pos += sizeof(double);
                                }

                            }
                        }
                        catch
                        {
                            //MessageBox.Show(err.Message);
                            label1.Text = "Done Convert";
                            label1.Update();
                        }
                    }*/
                }
            }
            catch (Exception ad)
            {
                MessageBox.Show(ad.Message);
                label1.Text = "Could not convert!";
                label1.Update();
                return;
            }
            label1.Text = "Done Convert";
            label1.Update();
        }
    }
    public class SBETstruct
    {
        public double time;
        public double lat;
        public double lon;
        public double alt;
        public double xvel;
        public double yvel;
        public double zvel;
        public double roll;
        public double pitch;
        public double heading;
        public double wander;
        public double xacc;
        public double yacc;
        public double zacc;
        public double xang;
        public double yang;
        public double zang;
    }
    public class vrms
    {
        public double time;
        public double lat;
        public double lon;
        public double alt;
        public double xvel;
        public double yvel;
        public double zvel;
        public double roll;
        public double pitch;
        public double heading;
    }
}

