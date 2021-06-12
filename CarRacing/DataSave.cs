using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    [Serializable]
    public class DataSave
    {
        //total coins collected until the application will be closed
        public int Coins { get; set; }
        //total cars buyed until the application will be closed
        public List<String> MyCars { get; set; }

        public DataSave(int Coins, List<String> MyCars)
        {
            this.Coins = Coins;
            this.MyCars = MyCars;
        }
        public static void Serialize(int Coins, List<String> MyCars)
        {
            DataSave data = new DataSave(Coins, MyCars);
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "");
            using (FileStream fileStream = new FileStream(path + "\\stats.dat", FileMode.OpenOrCreate))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, data);
            }
        }
        public static DataSave DeSerialize()
        {
            DataSave data;
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") +  "\\stats.dat";
            if (!File.Exists(path))
            {
                List<String> cars = new List<String>();
                cars.Add("yellow");
                Serialize(0, cars);
            }
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                IFormatter formatter = new BinaryFormatter();
                data = (DataSave)formatter.Deserialize(fileStream);
            }
            return data;
        }
    }
}
