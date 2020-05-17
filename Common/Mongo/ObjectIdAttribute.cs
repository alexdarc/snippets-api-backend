namespace Common.Mongo
{
    using System.ComponentModel.DataAnnotations;
    using MongoDB.Bson;

    public class ObjectIdAttribute
        : ValidationAttribute
    {
        public override bool IsValid(
            object value)
        {
            return !(value is string str) || ObjectId.TryParse(str, out _);
        }
    }
}
