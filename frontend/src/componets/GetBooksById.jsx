import axios from 'axios';
import React from 'react';
import { useState } from 'react';
import { useRef } from 'react';
import { Button, Card, Container, InputGroup, Form, FormControl, Alert } from 'react-bootstrap';

const GetBooksById = () => {

    const get_id = useRef(null);

    const [getResult, setGetResult] = useState(null);

    const formatResponse = (res) => {
        return JSON.stringify(res, null, 2);
    }

    async function getDataById() {
        const id = get_id.current.value;
        if (id) {
            try {
                const res = await axios.get(`https://localhost:44316/api/Books/GetBookById/${id}`);
                const result = {
                    data: res.data
                }

                setGetResult(formatResponse(result));

            } catch (err) {
                setGetResult(formatResponse(err.response?.data || err));
            }
        }
    }
    const clearGetOutput = () => {
        setGetResult(null);
    };

    return (
        <Container>
            <section>
                <Card>
                    <Card.Header>Search book by ID</Card.Header>
                    <Card.Body>
                        <InputGroup size="sm" className="mb-3">
                        <InputGroup.Text id="inputGroup-sizing-sm">Input</InputGroup.Text>
                        <FormControl ref={get_id} aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                            <Button variant="primary" onClick={getDataById}>Search</Button>
                        </InputGroup>
                        <Form>
                           
                        </Form>
                        <Button variant='secondary' onClick={clearGetOutput}> 
                        clear
                        </Button>
                    </Card.Body>
                    {getResult && <Alert variant='success'><pre>{getResult}</pre></Alert>}
                </Card>
            </section>
        </Container>
    );
};

export default GetBooksById;
