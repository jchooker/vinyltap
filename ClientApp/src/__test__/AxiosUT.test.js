import React, { useState, useEffect } from 'react';
import './css/GeneralSearch.css';
import { act, render, fireEvent, cleanup } from '@testing-library/react';
import AxiosMock from 'axios';
import AxiosUT from '../AxiosUT';

afterEach(cleanup);

it("async axios request", () => {
    AxiosMock.get.mockResolvedValue({ data: { title: "test title" } });
    const url = "/api/search/query";
    const {getByText, getByTextId} = render(<AxiosUT url={url} />);
})

// const AxiosUT = (props) => {
//     const [query, setQuery] = useState(''); //look up how to handle axios query w/ state?
//     const [axiosState, setAxiosState] = useState();

//     useEffect(() => {
//         axios.get(`http://localhost:5204/api/search/${query}`);
//     })
// };