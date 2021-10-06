namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    public class ProductImage
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int ImageID { get; set; }

        /// <summary>
        /// The <see cref="byte"/> data of the image (_The actual image_)
        /// </summary>
        public byte[] ImageStream { get; set; }

        public string Title { get; set; }
    }
}
