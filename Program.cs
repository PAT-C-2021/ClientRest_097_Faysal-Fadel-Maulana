using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Net;

namespace ClientRest_097_Faysal_Fadel_Maulana
{
    [DataContract]
    public class Mahasiswa
    {
        private string _nim, _nama, _prodi, _angkatan;
        [DataMember]
        public string nim
        {
            get { return _nim; }
            set { _nim = value; }
        }

        [DataMember]
        public string nama
        {
            get { return _nama; }
            set { _nama = value; }
        }

        [DataMember]
        public string prodi
        {
            get { return _prodi; }
            set { _prodi = value; }
        }
        [DataMember]
        public string angkatan
        {
            get { return _angkatan; }
            set { _angkatan = value; }
        }
    }

    class ClassData
    {
        public void getData()
        {
            var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);

            Console.Write("############ Data Mahasiswa ############");

            foreach (var mhs in data)
            {
                Console.Write("\n\nANGKATAN : " + mhs.angkatan);
                Console.Write("\nNIM      : " + mhs.nim);
                Console.Write("\nNAMA     : " + mhs.nama);
                Console.Write("\nPRODI    : " + mhs.prodi);
            }
            //Console.ReadLine();
        }
    }


    class Program
    {
        string baseUrl = "http://localhost:1907/";

        void BuatMahasiswa()
        {
            Console.WriteLine("\n\n############ Input Data Mahasiswa ############");

            Mahasiswa mhs = new Mahasiswa();
            Console.Write("\nMasukkan NIM       : ");
            mhs.nim = Console.ReadLine();
            Console.Write("\nMasukkan NAMA      : ");
            mhs.nama = Console.ReadLine();
            Console.Write("\nMasukkan PRODI     : ");
            mhs.prodi = Console.ReadLine();
            Console.Write("\nMasukkan ANGKATAN  : ");
            mhs.angkatan = Console.ReadLine();

            var data = JsonConvert.SerializeObject(mhs);
            var postData = new WebClient();
            postData.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string response = postData.UploadString(baseUrl + "Mahasiswa", data);
            Console.WriteLine(response);
        }


        static void Main(string[] args)
        {

            ClassData cl = new ClassData();
            cl.getData();
            Program app = new Program();
            app.BuatMahasiswa();
            
            Console.ReadLine();
        }
    }
}
