namespace IsMiller.CollectionCrawler.Abstractions
{
    /// <summary>
    /// Описывает контейнер для контейнеров содержащих элементы коллекции обхода.
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции для обхода.</typeparam>
    public interface INodesContainer<T>
    {
        /// <summary>
        /// Предоставляет контейнер элемента коллекции предшествующий элементу по текущей позиции.
        /// </summary>
        INode<T> Previous { get; }

        /// <summary>
        /// Предоставляет контейнер элемента коллекции по текущей позиции.
        /// </summary>
        INode<T> Current { get; }

        /// <summary>
        /// Предоставляет контейнер элемента коллекции следующий за элементом по текущей позиции.
        /// </summary>
        INode<T> Next { get; }
    }
}