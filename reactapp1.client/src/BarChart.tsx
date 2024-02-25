import { Bar } from 'react-chartjs-2';
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
            text: 'Min/Max temperature chart',
        },
    },
};

export default function App({ data }) {
    return (
        <div style={{ width: '600px', height: '400px' }}>
            {data ? (
                <Bar options={options} data={data} />
            ) : (
                <p>Loading...</p>
            )}
        </div>
    );
}
