import React, {useState} from 'react';
import GeneralSearch from './GeneralSearch';

function WelcomeContainer() {
    // const [searchResults, setSearchResults] = useState([]);

    // const handleSearchResults = (results) => {
    //     setSearchResults(results);
    // };

    return (
        <div>
            <h1>Welcome to VinylTap, the hub for buying LPs!</h1> <br />
            <div className='card'>
                <div className='card-header'> 
                    <h4>If you simply want to start exploring music, and our LP seller catalogue:</h4>
                </div>
                <div className='card-body'>
                    {/* <GeneralSearch searchMade={handleSearchResults} /> */}
                    <GeneralSearch />
                </div>
            </div>
            <br />
            <ul>
                <li><strong>Find rare LPs that others are selling</strong>. Our community links you to out-of-print vinyl records that might be more 
                abundant in certain geographical areas.</li>
            </ul>
            {/* <ul>
                {searchResults.map((result) => (
                    <li key={result.id}>{result.title}</li>
                ))}
            </ul>
            <br /> */}
        </div>
    )
}

export default WelcomeContainer