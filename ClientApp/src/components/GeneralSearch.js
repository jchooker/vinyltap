import React, { useState } from 'react';
import './css/GeneralSearch.css';
import GeneralSearchResultsTable from './GeneralSearchResultsTable';
import axios from 'axios';
import {capitalize} from '../util.js'


function GeneralSearch({searchMade}) {
    const [query, setQuery] = useState(''); //look up how to handle axios query w/ state?
    const [querySent, setQuerySent] = useState(false);
    const [searchResults, setSearchResults] = useState([]);

    const handleInputChange = (event) => {
        setQuery(event.target.value);
    };

    const handleQuerySent = () => {
        //event.preventDefault();
        //handleSearch();
        console.log(typeof searchResults)
        setQuerySent(true);
    };

    const processData = (data) => {
        let filteredRes;
        try {
            if (!data || !data.results || !Array.isArray(data.results)) {
                console.error('Invalid data format or missing "results" property.');
                return []; // Return an empty array in case of missing or invalid data
            }
            //console.log(artist);
            filteredRes = data.results.map((item) => {
                let artist, title;
                if (item.title) {
                    if(item.title.includes(' - ')) {
                        artist = item.title.split(' - ')[0].trim();
                        title = item.title.split(' - ')[1].trim();
                    }
                    else {
                        // artist = 'No Artist name provided';
                        // title = item.title.trim();
                        artist = item.title.trim();
                        title = 'No Title provided';
                    }
                    // artist = item.title.includes(' - ') ? item.title.split(' - ')[0].trim() : 'No Artist name provided';
                    // console.log(artist);
                } else {
                    artist = 'No Artist name provided';
                    title = '[No Title]';
                }
                let result_type = capitalize(item.type);
                // const albumTitle = title;
                // console.log(albumTitle);
                const genre = item.genre;
                const year = item.year;
                //const artist = item.title ? item.title.split(' - ').trim() : 'No Title / Artist provided'; // S/T scenario!!
                return {
                    result_type: result_type,
                    artist: artist, //<--need to make sure this accts for scenarios where it's self-titled or no artist beforeCreate() {
                                                                //the hyphen  
                    title: title,
                    genre: genre,
                    year: year,
                }
            });
        } catch(e) {
            console.error(e);
            return [];
        }
        return filteredRes;
        //const reg = /^(.*?)(?:\s\-\s|$)/; //without /g?...well we can just use split()
        //const artistMatch = data.results.title.match(reg);
    };

    const handleSearch = async (event) => {
        event.preventDefault();
        const api = axios.create({
            baseURL: 'https://localhost:7091/api/search',
            headers: {
                "Accept": "application/json",
                // "Accept": "application/x-www-form-urlencoded",
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Methods": "GET, POST, PATCH, PUT, DELETE, OPTIONS",
                "Access-Control-Allow-Headers": "Origin, Content-Type, X-Auth-Token, content-type",
                "Content-Type": "application/json",
                // "Content-Type": "application/x-www-form-urlencoded",
            },
            withCredentials: true
        })
        try {
            const response = await api.get(`?query=${query}`);
            //console.log(typeof response.data);
            if (typeof response.data === "string") {
                const jsonData = JSON.parse(response.data);
                //console.log(jsonData);
                const processedData = processData(jsonData);
                setSearchResults(processedData);
            } else {
                const processedData = processData(response.data);
                setSearchResults(processedData);
                console.log(typeof processedData);
            }
            // if(response) console.log(response);
            // else console.log('no response');
            // if(response.data) console.log(response.data);
        } catch (err) { 
            console.error(err.response); 
            // console.error(err.response.data); 
            // console.error(err.response.status); 
            // console.error(err.response.headers); 

        }
    };

    return (
        <div>
            <form onSubmit={handleSearch}>
            {/* <form onSubmit={async (event) => await handleSearch(event)}>  */}
            {/* ^^removed when I reformatted fetch function */}
            {/* <form onSubmit={handleQuerySent}> */}
                <div className='row'>
                    <div className='col-9'>
                        <input type="text" value={query} placeholder="Explore artists, albums, genres and more!" 
                        className='form-control input-img-placeholder'
                        onChange={handleInputChange}/>
                    </div>
                    <div className='d-grid col-2'>
                        <button type='submit' className='btn btn-success' onClick={handleQuerySent}>Search</button>
                    </div>
                </div>
            </form>
            <br />
            {querySent && <GeneralSearchResultsTable searchResults={searchResults} />} 
            {/* ^account for results erroneous or otherwise */}
        </div>
    )
}

export default GeneralSearch;