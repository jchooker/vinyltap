import React, { useState } from 'react';
import './css/GeneralSearch.css';
import axios from 'axios';

function GeneralSearch({searchMade}) {
    const [query, setQuery] = useState('');

    const handleSearch = async (event) => {
        event.preventDefault();
        try {
            const response = await axios.get(`/search/${query}`);
            if (response.status === '200') {
                const data = await response.json();
                searchMade(data);
            } 
            // else {
            //     console.error(response.status);
            // }
        } catch (err) {
            console.error(err);
        }
    };

    return (
        <div>
            <form onSubmit={handleSearch}>
                <div className='row'>
                    <div className='col-9'>
                        <input type="text" value={query} placeholder="Explore artists, albums, genres and more!" 
                        className='form-control input-img-placeholder'
                        onChange={(e) => setQuery(e.target.value)}/>
                    </div>
                    <div className='d-grid col-2'>
                        <button type='submit' className='btn btn-success'>Search</button>
                    </div>
                </div>
            </form>
        </div>
    )
}

export default GeneralSearch;