using Domain.Models;

namespace BlazorWASM.Services;

public class BookStateService
{
    public BookRegistry CurrentBook { get; private set; }

    public event Action OnChange;

    public void SetCurrentBook(BookRegistry book)
    {
        CurrentBook = book;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}