using System.Xml.Serialization;

namespace EnergomerWebApp.Database.Xml.Fields
{
    // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    [XmlRoot(Namespace = "http://www.opengis.net/kml/2.2", IsNullable = false)]

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
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
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
        [XmlAttribute()]
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
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentSchema
    {

        private kmlDocumentSchemaSimpleField[] simpleFieldField;

        private string nameField;

        private string idField;

        /// <remarks/>
        [XmlElement("SimpleField")]
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
        [XmlAttribute()]
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
        [XmlAttribute()]
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
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentSchemaSimpleField
    {

        private string nameField;

        private string typeField;

        /// <remarks/>
        [XmlAttribute()]
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
        [XmlAttribute()]
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
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
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
        [XmlElement("Placemark")]
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
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemark
    {

        private string nameField;

        private kmlDocumentFolderPlacemarkStyle styleField;

        private kmlDocumentFolderPlacemarkExtendedData extendedDataField;

        private kmlDocumentFolderPlacemarkPolygon polygonField;

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
        public kmlDocumentFolderPlacemarkStyle Style
        {
            get
            {
                return styleField;
            }
            set
            {
                styleField = value;
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
        public kmlDocumentFolderPlacemarkPolygon Polygon
        {
            get
            {
                return polygonField;
            }
            set
            {
                polygonField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkStyle
    {

        private kmlDocumentFolderPlacemarkStyleLineStyle lineStyleField;

        private kmlDocumentFolderPlacemarkStylePolyStyle polyStyleField;

        /// <remarks/>
        public kmlDocumentFolderPlacemarkStyleLineStyle LineStyle
        {
            get
            {
                return lineStyleField;
            }
            set
            {
                lineStyleField = value;
            }
        }

        /// <remarks/>
        public kmlDocumentFolderPlacemarkStylePolyStyle PolyStyle
        {
            get
            {
                return polyStyleField;
            }
            set
            {
                polyStyleField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkStyleLineStyle
    {

        private string colorField;

        /// <remarks/>
        public string color
        {
            get
            {
                return colorField;
            }
            set
            {
                colorField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkStylePolyStyle
    {

        private byte fillField;

        /// <remarks/>
        public byte fill
        {
            get
            {
                return fillField;
            }
            set
            {
                fillField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
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
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkExtendedDataSchemaData
    {

        private kmlDocumentFolderPlacemarkExtendedDataSchemaDataSimpleData[] simpleDataField;

        private string schemaUrlField;

        /// <remarks/>
        [XmlElement("SimpleData")]
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
        [XmlAttribute()]
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
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkExtendedDataSchemaDataSimpleData
    {

        private string nameField;

        private byte valueField;

        /// <remarks/>
        [XmlAttribute()]
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
        [XmlText()]
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
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkPolygon
    {

        // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
        [XmlRoot(Namespace = "http://www.opengis.net/kml/2.2", IsNullable = false)]
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
        [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
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
            [XmlAttribute()]
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
        [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
        public partial class kmlDocumentSchema
        {

            private kmlDocumentSchemaSimpleField[] simpleFieldField;

            private string nameField;

            private string idField;

            /// <remarks/>
            [XmlElement("SimpleField")]
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
            [XmlAttribute()]
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
            [XmlAttribute()]
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
        [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
        public partial class kmlDocumentSchemaSimpleField
        {

            private string nameField;

            private string typeField;

            /// <remarks/>
            [XmlAttribute()]
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
            [XmlAttribute()]
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
        [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
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
            [XmlElement("Placemark")]
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
        [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
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
        [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
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
        [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
        public partial class kmlDocumentFolderPlacemarkExtendedDataSchemaData
        {

            private kmlDocumentFolderPlacemarkExtendedDataSchemaDataSimpleData[] simpleDataField;

            private string schemaUrlField;

            /// <remarks/>
            [XmlElement("SimpleData")]
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
            [XmlAttribute()]
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
        [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
        public partial class kmlDocumentFolderPlacemarkExtendedDataSchemaDataSimpleData
        {

            private string nameField;

            private byte valueField;

            /// <remarks/>
            [XmlAttribute()]
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
            [XmlText()]
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
        [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
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


        private kmlDocumentFolderPlacemarkPolygonOuterBoundaryIs outerBoundaryIsField;

        /// <remarks/>
        public kmlDocumentFolderPlacemarkPolygonOuterBoundaryIs outerBoundaryIs
        {
            get
            {
                return outerBoundaryIsField;
            }
            set
            {
                outerBoundaryIsField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkPolygonOuterBoundaryIs
    {

        private kmlDocumentFolderPlacemarkPolygonOuterBoundaryIsLinearRing linearRingField;

        /// <remarks/>
        public kmlDocumentFolderPlacemarkPolygonOuterBoundaryIsLinearRing LinearRing
        {
            get
            {
                return linearRingField;
            }
            set
            {
                linearRingField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public partial class kmlDocumentFolderPlacemarkPolygonOuterBoundaryIsLinearRing
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
