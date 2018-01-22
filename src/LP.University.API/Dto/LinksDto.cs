using System.Collections.ObjectModel;

namespace LP.University.API.Dto
{
    public abstract class LinksCollection : Collection<LinkDto>
    {
        public void Add(string rel, string href)
        {
            if (string.IsNullOrWhiteSpace(rel)) throw new System.ArgumentException("message", nameof(rel));
            if (string.IsNullOrWhiteSpace(href)) throw new System.ArgumentException("message", nameof(href));

            //base.Add(new LinkDto
            //{
            //    Rel = rel,
            //    Href = href
            //});
        }
    }

    public class LinkDto
    {
        public string Href { get; set; }
    }
}
