import React, { useState, useEffect } from 'react';
import { Bar } from 'react-chartjs-2';
import axios from 'axios';
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    BarElement,
    Title,
    Tooltip,
    Legend,
} from 'chart.js';

ChartJS.register(
    CategoryScale,
    LinearScale,
    BarElement,
    Title,
    Tooltip,
    Legend
);

export const options = {
    responsive: true,
    plugins: {
        legend: {
            position: 'top' as const,
        },
        title: {
            display: true,
            text: 'Chart.js Bar Chart',
        },
    },
};

const initialData = {
    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
    datasets: [
        {
            label: 'Dataset 1',
            data: Array(7).fill(55),
            backgroundColor: 'rgba(255, 99, 132, 0.5)',
        },
        { 
            label: 'Dataset 2',
            data: Array(7).fill(66),
            backgroundColor: 'rgba(53, 162, 235, 0.5)',
        },
    ],
};


export const data = {
    labels: initialData.labels,
    datasets: [
        {
            label: 'Dataset 1',
            data: initialData.labels.map(() => 55),
            backgroundColor: 'rgba(255, 99, 132, 0.5)',
        },
        {
            label: 'Dataset 2',
            data: initialData.labels.map(() => 66),
            backgroundColor: 'rgba(53, 162, 235, 0.5)',
        },
    ],
};


export default function App() {
    const [data, setData] = useState(initialData);

    useEffect(() => {
        async function fetchData() {
            try {
                const response = await axios.get('https://localhost:7121/Weather/GetCityWeatherData');
                console.log(response.data);
                const locations = response.data.map(item => item.location);
                const minimalTemperatures = response.data.map(item => item.minimalTemperature);
                const maximumTemperatures = response.data.map(item => item.maximumTemperature);
                console.log(locations);
                console.log(minimalTemperatures);
                console.log(maximumTemperatures);
                const newData = {
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
                };
                setData(newData);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        }

        fetchData();
    }, []);

    return (
        <div style={{ width: '600px', height: '400px' }}>
            <Bar options={options} data={data} />
        </div>
    );
}