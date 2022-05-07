namespace Ropey.Models
{
    public class ActorMovieList
    {
        private IQueryable<Dvdtitle> dvdtitles;

        public ActorMovieList(string actorName, IQueryable<Dvdtitle> dvdtitles)
        {
            ActorName = actorName;
            this.dvdtitles = dvdtitles;
        }

        public string ActorName { get; set; }
        public string MovieName { get; set; }


    }
}
