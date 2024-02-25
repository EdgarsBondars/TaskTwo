import React, { useState, useEffect } from 'react';
import axios from 'axios';
import BarChart from './BarChart';

interface WeatherData {
    location: string;
    minimalTemperature: number;
    maximumTemperature: number;
}

const App: React.FC = () => {
    const [data, setData] = useState<{ labels: string[], datasets: { label: string, data: number[], backgroundColor: string }[] }>({
        labels: [],
        datasets: [],
    });

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get<WeatherData[]>('https://localhost:7121/Weather/GetCityWeatherData');
                const locations = response.data.map(item => item.location);
                const minimalTemperatures = response.data.map(item => item.minimalTemperature);
                const maximumTemperatures = response.data.map(item => item.maximumTemperature);

                setData({
                    labels: locations,
                    datasets: [
                        {
                            label: 'Min temperature',
                            data: minimalTemperatures,
                            backgroundColor: 'rgba(255, 99, 132, 0.5)',
                        },
                        {
                            label: 'Max temperature',
                            data: maximumTemperatures,
                            backgroundColor: 'rgba(53, 162, 235, 0.5)',
                        },
                    ],
                });
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, []);

    return (
        <div className="App">
            <BarChart data={data} />
        </div>
    );
};

export default App;
