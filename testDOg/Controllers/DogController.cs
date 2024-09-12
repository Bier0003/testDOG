using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace testDOG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        //get api/Dog
        [HttpGet]

        public IActionResult GetBreed()
        {

            string breedfilePath = Path.Combine(Directory.GetCurrentDirectory(), "Dog.json");
            string pictureFilePath = Path.Combine(Directory.GetCurrentDirectory(), "breeds.json");

            //check file if it exit
            if (!System.IO.File.Exists(breedfilePath) || !System.IO.File.Exists(pictureFilePath))
            {
                return NotFound("One or Both Json file not found");
            }

            // Read the json file and deserialize the content into list of Dog object
            var BreedJson = System.IO.File.ReadAllText(breedfilePath);
            var Breeds = JsonConvert.DeserializeObject<List<string>>(BreedJson);

            var PictureJson = System.IO.File.ReadAllText(pictureFilePath);
            var Picture = JsonConvert.DeserializeObject<List<string>>(PictureJson);



            //return the first dog or massage if the list is empthy

            if (Breeds == null || Picture == null || Breeds.Count != Picture.Count)
            {
                return BadRequest("Mismatch between number of breeds and picuter");
            }

            var dogs = new List<Dog>();
            for (int i = 0; i < Breeds.Count; i++)
            {
                dogs.Add(new Dog
                {
                    Breed = Breeds[i],
                    Picture = Picture[i]
                });
            }

            // Return the combined data as JSON
            return Ok(dogs);
        }
    }
            public class Dog
        {
            public string Breed { get; set; }
            public string Picture { get; set; }
        }


            //var dogData = Breeds?.FirstOrDefault();
            //if (dogData == null)
            //{
            //    return NotFound("No Dog file found in json file");
            //}

            //var DogData = new Dog
            //{

            //    breeds = "Golden Retriever",

            //    picture = "C:\\Users\\Bier0003\\source\\repos\\testDOg\\golden.jpg"

            //};


        
    
}
