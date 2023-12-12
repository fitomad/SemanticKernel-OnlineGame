using System.ComponentModel;
using Microsoft.SemanticKernel;

using Intelligence.Data;

namespace Intelligence.Plugins;


public class Backpack
{
    private BackpackRepository _repository = new BackpackRepository();

    [KernelFunction, Description("Añade un nuevo elemento a la mochila del jugador.")]
    public void Add([Description("Nombre del elemento que se añade a la mochila del jugador.")] string element)
    {
        _repository.Insert(element);
    }

    [KernelFunction, Description("Quita un elemento de la mochila del jugador.")]
    public void Remove([Description("Nombre del elemento que se elimina de la mochila del jugador.")] string element)
    {
        _repository.Delete(element);
    }

    [KernelFunction, Description("Obtiene una lista de todos los elementos disponibles en la mochila del jugador.")]
    public string List()
    {
        string elements = _repository
            .FetchAll()
            .Aggregate((firstElement, secondElement) => 
            {
                return $"{firstElement}, {secondElement}";
            });

        return elements;
    }
}