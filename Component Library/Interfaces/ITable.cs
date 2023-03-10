namespace Component_Library
{
    public interface ITable
    {
        void Refresh();
        Task UpdateAsync();
        string GlobalSearch { get; set; }
        bool ShowSearchBar { get; set; }
    }
}
