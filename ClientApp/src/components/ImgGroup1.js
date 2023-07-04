import React from 'react';
import PropTypes from 'prop-types';
import './css/ImgGroup1.css';
import Row from 'react-bootstrap/Row';
import bootstrap from 'bootstrap/dist/css/bootstrap.css';

function ImgGroup1(props) {
  return (
    <div>
        <Row>
            <div className='d-flex justify-content-evenly img-row'>
                <img src='https://i.ibb.co/ScQKwqw/icon1.png' alt='row-record-icon' title='row-record-icon'></img>
                <img src='https://i.ibb.co/DV2mVfN/icon2.png' alt='row-regg-icon' title='row-regg-icon'></img>
                <img src='https://i.ibb.co/BLshRzf/icon3.png' alt='row-budd-icon' title='row-budd-icon'></img>
                <img src='https://i.ibb.co/khkgD0d/icon4.jpg' alt='row-strav-icon' title='row-strav-icon'></img>
                <img src='https://i.ibb.co/4PzRsmM/icon5.jpg' alt='row-bayin-icon' title='row-bayin-icon'></img>
            </div>
        </Row>
    </div>
  )
}

ImgGroup1.propTypes = {}

export default ImgGroup1
