namespace HotelProject.WebUI.Dtos.FollowersDto
{
    public class ResultInstagramFollowersDto
    {
        public Data data { get; set; }

        public class Data
        {
            public int followers { get; set; }
            public int following { get; set; }
        }

        
    }
}
