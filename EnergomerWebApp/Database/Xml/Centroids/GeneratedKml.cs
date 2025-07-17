namespace EnergomerWebApp.Database.Xml.Centroids
{
    // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.opengis.net/kml/2.2", IsNullable = false)]
    public partial class kml
    {

        private kmlDocument documentField;

        /// <remarks/>
        public kmlDocument Document
        {
            get
            {
                return documentField;
            }
            set
            {
                documentField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocument
    {

        private kmlDocumentSchema schemaField;

        private kmlDocumentFolder folderField;

        private string idField;

        /// <remarks/>
        public kmlDocumentSchema Schema
        {
            get
            {
                return schemaField;
            }
            set
            {
                schemaField = value;
            }
        }

        /// <remarks/>
        public kmlDocumentFolder Folder
        {
            get
            {
                return folderField;
            }
            set
            {
                folderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentSchema
    {

        private kmlDocumentSchemaSimpleField[] simpleFieldField;

        private string nameField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("SimpleField")]
        public kmlDocumentSchemaSimpleField[] SimpleField
        {
            get
            {
                return simpleFieldField;
            }
            set
            {
                simpleFieldField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string name
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentSchemaSimpleField
    {

        private string nameField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string name
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolder
    {

        private string nameField;

        private kmlDocumentFolderPlacemark[] placemarkField;

        /// <remarks/>
        public string name
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("Placemark")]
        public kmlDocumentFolderPlacemark[] Placemark
        {
            get
            {
                return placemarkField;
            }
            set
            {
                placemarkField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemark
    {

        private string nameField;

        private kmlDocumentFolderPlacemarkExtendedData extendedDataField;

        private kmlDocumentFolderPlacemarkPoint pointField;

        /// <remarks/>
        public string name
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }

        /// <remarks/>
        public kmlDocumentFolderPlacemarkExtendedData ExtendedData
        {
            get
            {
                return extendedDataField;
            }
            set
            {
                extendedDataField = value;
            }
        }

        /// <remarks/>
        public kmlDocumentFolderPlacemarkPoint Point
        {
            get
            {
                return pointField;
            }
            set
            {
                pointField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkExtendedData
    {

        private kmlDocumentFolderPlacemarkExtendedDataSchemaData schemaDataField;

        /// <remarks/>
        public kmlDocumentFolderPlacemarkExtendedDataSchemaData SchemaData
        {
            get
            {
                return schemaDataField;
            }
            set
            {
                schemaDataField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkExtendedDataSchemaData
    {

        private kmlDocumentFolderPlacemarkExtendedDataSchemaDataSimpleData[] simpleDataField;

        private string schemaUrlField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("SimpleData")]
        public kmlDocumentFolderPlacemarkExtendedDataSchemaDataSimpleData[] SimpleData
        {
            get
            {
                return simpleDataField;
            }
            set
            {
                simpleDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string schemaUrl
        {
            get
            {
                return schemaUrlField;
            }
            set
            {
                schemaUrlField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkExtendedDataSchemaDataSimpleData
    {

        private string nameField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string name
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public byte Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkPoint
    {

        private string coordinatesField;

        /// <remarks/>
        public string coordinates
        {
            get
            {
                return coordinatesField;
            }
            set
            {
                coordinatesField = value;
            }
        }
    }
}
