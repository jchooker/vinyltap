import React, { useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import ConfigForm from './components/ConfigForm';
import { Layout } from './components/Layout';
import './App.css'
//import './custom.css';

function App() {
  const [addTokensModalOpen, setAddTokensModalOpen] = useState(false);
  
  const currYr = new Date().getFullYear();
  
  return (
    <Layout>
      {addTokensModalOpen && <ConfigForm />}
      <Routes>
        {AppRoutes.map((route, index) => {
          const { element, ...rest } = route;
          return <Route key={index} {...rest} element={element} />;
        })}
        {/* ^^Continue working on scenario where .env file is missing and user still needs to make api call */}
        {/* If file is not present (see Extensions/ConfigExtensions) how will backend prompt frontend */}
        {/* to generate popup modal with inputs? There is currently no component logic to the check for .env's */}
        {/* existence (which should happen **every time** the general search is used? or for a "session"?) */}
        {/* and where the popup modal is placed within the structure of the frontend */}
      </Routes>
      <p>© {currYr} Joseph Hooker</p>
    </Layout>
  );
}

export default App; 
