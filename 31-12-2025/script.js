// Random Facts API

// let Url = "https://api.api-ninjas.com/v1/quotes";
// let button = document.querySelector(".btn");
// let msg = document.querySelector(".msg");

// button.addEventListener("click", () => {
//     let data =  fetch(Url, {
//   headers: {
//     "X-Api-Key": "Your_Api_Key"
//   }
// })
// .then(res => res.json())
// .then(data => msg.innerText = data[0].quote)
// .then(data =>console.log(data[0]))
// .catch(err => console.log(err));
// })

// Weather forecast
let Url = "https://api.api-ninjas.com/v1/weather?lat=28.61&lon=77.23"; 
let button = document.querySelector(".btn");
let msg = document.querySelector(".msg");
const citySelect = document.getElementById("citySelect");

const WeatherCities = CityList.map(city => ({
  name: city.city,
  lat: Number(city.lat),
  lon: Number(city.lng)
}));

WeatherCities.forEach(city => {
  const option = document.createElement("option");
  option.textContent = city.name;
  option.value = `${city.lat},${city.lon}`;
  citySelect.appendChild(option);
});

button.addEventListener("click", async () => {
  try {
    if (!citySelect.value) {
      msg.innerText = "Please select a city";
      return;
    }

    const [lat, lon] = citySelect.value.split(",");

    const url = `https://api.api-ninjas.com/v1/weather?lat=${lat}&lon=${lon}`;

    const res = await fetch(url, {
      headers: {
        "X-Api-Key": "Your_Api_Key"
      }
    });

    if (!res.ok) throw new Error("API Error");

    const data = await res.json();

    msg.innerText = `
      Temperature: ${data.temp}°C
      Feels Like: ${data.feels_like}°C
      Humidity: ${data.humidity}%
      Wind Speed: ${data.wind_speed} km/h
      Clouds: ${data.cloud_pct}%
          `;
  } catch (err) {
    console.error(err);
    msg.innerText = "Failed to load weather data";
  }
});
