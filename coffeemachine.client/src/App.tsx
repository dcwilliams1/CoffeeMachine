import { useState } from 'react';
import './App.css';

interface Coffee {
    message: string;
}

function App() {
    const [response, setResponse] = useState<Coffee | undefined>();

    const getCoffee = async (machineType: string) => {
        try {
            const response = await fetch('getCoffee?machineType=' + machineType);
            if (response.ok) {
                const data = await response.json();
                setResponse(data);
            } else {
                setResponse({ message: "Could not make coffee. Please try again later." });
            }
        } catch (error) {
            console.error("Failed to fetch coffee:", error);
            setResponse({ message: "The coffee machine is not available. Please try again later." });
        }
    };

    const coffeeInvitation =
        <div>
            <h1 id="tableLabel">Get Coffee</h1>
            <p>Please choose either ground or standard coffee.</p>
            <div>
                <input type="button" value="Standard" onClick={() => getCoffee("standard")}></input>
                <input type="button" value="Ground" onClick={() => getCoffee("grinding")}></input>
            </div>
        </div>

    const contents = response === undefined
        ? (<div className="centeredContent">
            {coffeeInvitation}
        </div>)
        : (<div className="centeredContent">
            {coffeeInvitation}
            <p>{response.message}</p>
        </div>);


    return (
        <div>
            {contents}
        </div>
    );

}


export default App;