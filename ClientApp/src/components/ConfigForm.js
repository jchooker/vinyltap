import React, {useState, useEffect} from 'react';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import axios from 'axios';

const ConfigForm = () => {
    const [modalIsVisible, setModalIsVisible] = useState(false);
    const [consumerKey, setConsumerKey] = useState('');
    const [consumerSecret, setConsumerSecret] = useState('');
    const [oAuthToken, setOAuthToken] = useState('');
    const [oAuthTokenSecret, setOAuthTokenSecret] = useState('');

    useEffect(() => {
        checkEnvFile();
    }, []);

    const checkEnvFile = async () => {
        try {
            const response = await axios.get('/api/envfile');
        } catch (err) {
            console.error(err);
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        console.log('submit');
        try {
            const config = {consumerKey, consumerSecret, oAuthToken, oAuthTokenSecret};

            await axios.post('/api/configuration', config);

            console.log("Config saved");
        } catch (err) {
            console.error(err);
        }
        setModalIsVisible(false);
    };
    return (
        <div>
            <Modal>
                <Modal.Header>
                    <Modal.Title>No Environment Variables - Please Manually Input</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={handleSubmit}>
                        <Form.Group controlId="consumerKey">
                            <Form.Label>Consumer Key</Form.Label>
                            <Form.Control type="text" placeholder="Consumer Key" value={consumerKey} onChange={(e) => setConsumerKey(e.target.value)} />
                        </Form.Group>
                        <Form.Group controlId="consumerSecret">
                            <Form.Label>Consumer Secret</Form.Label>
                            <Form.Control type="text" placeholder="Consumer Secret" value={consumerSecret} onChange={(e) => setConsumerSecret(e.target.value)} />
                        </Form.Group>
                        <Form.Group controlId="oAuthToken">
                            <Form.Label>OAuth Token</Form.Label>
                            <Form.Control type="text" placeholder="OAuth Token" value={oAuthToken} onChange={(e) => setOAuthToken(e.target.value)} />
                        </Form.Group>
                        <Form.Group controlId="oAuthTokenSecret">
                            <Form.Label>OAuth Token Secret</Form.Label>
                            <Form.Control type="text" placeholder="OAuth Token Secret" value={oAuthTokenSecret} onChange={(e) => setOAuthTokenSecret(e.target.value)} />
                        </Form.Group>
                        <Button variant="primary" type="submit">Save API Tokens</Button>
                        <Button variant="secondary" type="cancel">Cancel</Button> 
                        {/* ^^What happens when they cancel? */}
                    </Form>
                </Modal.Body>

            </Modal>
        </div>
    )
}

export default ConfigForm