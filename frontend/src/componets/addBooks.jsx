import React, { useState } from 'react';
import axios from 'axios';
import { Alert, Button, Container, Form } from 'react-bootstrap';


const AddBooks = () => {

    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [pageCount, setCount] = useState("");
    const [publishDate, setDate] = useState("");
    const [excerpt, setExcerpt] = useState("");

    const [postResult, setPostResult] = useState(null);

    const fortmatResponse = (res) => {
        return JSON.stringify(res, null, 2);
    };

    const post = async () => {
        const data = { title, description, pageCount, publishDate, excerpt };

        try {
            const response = await axios.post(
                "https://localhost:44316/api/Books/", data
            );

            const result ={
                data: response.data
            }

            setPostResult(fortmatResponse(result));
        } catch (error) {
            setPostResult(fortmatResponse(error.response?.data || error))
        }





    }


    return (
        <Container>
            <Form className='form-control'>
                <Form.Group className='mb-3'>
                    <Form.Label>Title</Form.Label>
                    <Form.Control type='text' placeholder='Introduce a Title' value={title} onChange={(e) => setTitle(e.target.value)}></Form.Control>
                    <Form.Label>Description</Form.Label>
                    <Form.Control type='text' placeholder='Introduce a Description' value={description} onChange={(e) => setDescription(e.target.value)}></Form.Control>
                    <Form.Label>Excertp</Form.Label>
                    <Form.Control type='text' placeholder='Introduce an Excerpt' value={excerpt} onChange={(e) => setExcerpt(e.target.value)}></Form.Control>
                    <Form.Label>Number pages</Form.Label>
                    <Form.Control type='number' placeholder='Introduce the number of pages' value={pageCount} onChange={(e) => setCount(e.target.value)}></Form.Control>
                    <Form.Label>Publish Date</Form.Label>
                    <Form.Control type='date' placeholder='Introduce a publish Date' value={publishDate} onChange={(e) => setDate(e.target.value)}></Form.Control>
                </Form.Group>
                <Button variant='primary' onClick={post}>
                    Submit
                </Button>
                {postResult && <Alert variant="success"><pre>{postResult}</pre></Alert>}
            </Form>


        </Container>
    );

}

export default AddBooks;