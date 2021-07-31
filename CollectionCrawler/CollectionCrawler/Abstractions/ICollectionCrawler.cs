using IsMiller.CollectionCrawler.Models;

namespace IsMiller.CollectionCrawler.Abstractions
{
    /// <summary>
    /// Описывает методы для обхода коллекции.
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции.</typeparam>
    public interface ICollectionCrawler<T>
    {
        /// <summary>
        /// Выполняет попытку продвижения обхода по коллекции на один элемент вперед.
        /// </summary>
        /// <returns><see langword="true"/> - если продвижение выполнено успешно,
        /// иначе <see langword="false"/>.</returns>
        bool TryMoveForward();

        /// <summary>
        /// Выполняет попытку продвижения обхода по коллекции на один элемент обратно.
        /// </summary>
        /// <returns><see langword="true"/> - если продвижение выполнено успешно,
        /// иначе <see langword="false"/>.</returns>
        bool TryMoveBack();

        /// <summary>
        /// Выполняет предоставление экземпляра класса <see cref="NodeContainer{T}"/>
        /// содержащего предыдущий, текущий и следующий элемент коллекции по индексу текущей позиции.
        /// </summary>
        /// <returns>экземпляра класса <see cref="NodeContainer{T}"/>.</returns>
        INodesContainer<T> GetCurrent();

        /// <summary>
        /// Выполняет попытку перемещения обхода по коллекции на указанную позицию.
        /// </summary>
        /// <returns><see langword="true"/> - если перемещение выполнено успешно,
        /// иначе <see langword="false"/>.</returns>
        bool TryMoveToPosition(int position);
    }
}