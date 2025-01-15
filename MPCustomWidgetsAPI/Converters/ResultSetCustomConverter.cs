using Ical.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Platform.Clients.PowerService;
using System.Xml.Linq;

namespace MicroServices.Converters
{
    public class ResultSetCustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType.Name == "ResultSet")
            {
                return true;
            }

            return false;
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            //KeyValuePair<string, object> item = (KeyValuePair<string, object>)value;

            ResultSet results = (ResultSet)value;

            IEnumerable<RecordSet> recordSets = results;
            IEnumerable<Record> firstSetRecords = recordSets.First();

            // Multiple Arrays
            // Return Array of Arrays

            writer.WriteStartObject();

            int recordSetCounter = 1;

            foreach (RecordSet recordSet in recordSets)                
            {
                writer.WritePropertyName($"DataSet{recordSetCounter}");
                recordSetCounter++;

                writer.WriteStartArray();

                foreach (Record row in recordSet)
                {
                    WriteJsonRow(writer, row);
                }

                writer.WriteEndArray();
            }              

            writer.WriteEndObject();

        }

        private void WriteJsonValue(JsonWriter writer, object? value)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            if (value.GetType() == typeof(string))
            {
                writer.WriteValue(value.ToString());
            }
            else if (value.GetType() == typeof(DateTime))
            {
                DateTime dt = (DateTime)value;
                writer.WriteValue(dt.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
            }
            else
            {
                writer.WriteValue(value);
            }
        }

        private void WriteJsonRow(JsonWriter writer, Record row)
        {
            writer.WriteStartObject();
            foreach (var element in row)
            {
                writer.WritePropertyName(element.Key.ToString());

                WriteJsonValue(writer, element.Value);
            }
            writer.WriteEndObject();
        }
    }
}
