import React from 'react';
import Table from 'react-bootstrap/Table';

const GeneralSearchResultsTable = ({searchResults}) => {
    return (
        <Table responsive striped>
            <thead>
                <tr>
                    <th>Result Type</th>
                    <th>Artist</th>
                    <th>Title</th>
                    <th>Genre</th>
                    <th>Year</th>
                </tr>
            </thead>
            <tbody>
                {searchResults.map((item, index) => (
                    <tr key={index}>
                        <td>{item.result_type}</td>
                        <td>{item.artist}</td>
                        <td>{item.title}</td>
                        <td>{item.genre}</td>
                        <td>{item.year}</td>
                    </tr>
                ))}
            </tbody>
        </Table>
    )
};

export default GeneralSearchResultsTable;