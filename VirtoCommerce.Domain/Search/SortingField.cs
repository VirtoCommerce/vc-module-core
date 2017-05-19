namespace VirtoCommerce.Domain.Search
{
    public class SortingField
    {
        public SortingField()
        {
        }

        public SortingField(string fieldName)
        {
            FieldName = fieldName;
        }

        public SortingField(string fieldName, bool isDescending)
        {
            FieldName = fieldName;
            IsDescending = isDescending;
        }

        public string FieldName { get; set; }
        public bool IsDescending { get; set; }
    }
}
