using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Vehicle_Source
{
    public class XMLSet<TModel> where TModel : class
    {
        private string _filename;
        private ICollection<TModel> _models;

        public XMLSet(string fileName)
        {
            _filename = fileName;
        }

        public ICollection<TModel> Data
        {
            get
            {
                try
                {
                    if (_models == null) Load();
                }
                catch
                {
                    _models = new List<TModel>();
                }
                return _models;
            }
            set
            {
                _models = value;
                Save();
            }
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<TModel>));
            using (StreamWriter sw = new StreamWriter(_filename))
            {
                serializer.Serialize(sw, _models);
            }
        }

        public void Load()
        {
            if (!File.Exists(_filename))
            {
                _models = new List<TModel>();
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<TModel>));
            using (StreamReader sr = new StreamReader(_filename))
            {
                _models = serializer.Deserialize(sr) as List<TModel>;
            }
        }
    }
}
