//
// Mono.Tools.LocaleBuilder.CultureInfoEntry
//
// Author(s):
//  Jackson Harper (jackson@ximian.com)
//
// (C) 2004 Novell, Inc (http://www.novell.com)
//


using System;
using System.Text;

namespace Mono.Tools.LocaleBuilder {

        public class CultureInfoEntry : Entry {

                public string Language;
                public string Territory;
                public string EnglishName;
                public string DisplayName;
                public string NativeName;
                public string IcuName;
                public string Win3Lang;
                public string ISO2Lang;
                public string ISO3Lang;
                public string Lcid;
                public string ParentLcid;
                public string SpecificLcid;
                public DateTimeFormatEntry DateTimeFormatEntry;
                public NumberFormatEntry NumberFormatEntry;
                public int [] CalendarData = new int [5];
                public int DateTimeIndex;
                public int NumberIndex;
                
                
                public int Row;

                public CultureInfoEntry ()
                {
                        DateTimeFormatEntry = new DateTimeFormatEntry ();
                        NumberFormatEntry = new NumberFormatEntry ();
                }

                public string Name {
                        get {
                                if (Territory == null)
                                        return Language;
                                return Language + "-" + Territory;
                        }
                }

                public override string ToString ()
                {
                        StringBuilder builder = new StringBuilder ();
                        AppendTableRow (builder);
                        return builder.ToString ();
                }

                public void AppendTableRow (StringBuilder builder)
                {
                        builder.Append ("\t{");
                        builder.AppendFormat ("{0}, {1}, {2}, " +
                                        "\"{3}\", \"{4}\", \"{5}\", " +
                                        "\"{6}\", \"{7}\", \"{8}\", " +
                                        "\"{9}\", \"{10}\", " +
                                        "{11}, " +
                                        "{12}, {13}",
                                        Lcid, ParentLcid, SpecificLcid,
                                        EncodeString (Name), EncodeString (IcuName), EncodeString (EnglishName),
                                        EncodeString (DisplayName), EncodeString (NativeName), EncodeString (Win3Lang),
                                        EncodeString (ISO3Lang), EncodeString (ISO2Lang),
                                        ValuesString (CalendarData),
                                        DateTimeFormatEntry == null ? -1 : DateTimeFormatEntry.Row,
                                        NumberFormatEntry == null ? -1 : NumberFormatEntry.Row);
                        builder.Append ('}');
                }

                private string ValuesString (int [] values)
                {
                        StringBuilder builder = new StringBuilder ();
                        builder.Append ('{');
                        for (int i=0; i<values.Length; i++) {
                                builder.Append (values [i].ToString ());
                                if (i+1 < values.Length)
                                        builder.Append (", ");
                        }
                        builder.Append ("}");
                        return builder.ToString ();
                }
        }
        
}

