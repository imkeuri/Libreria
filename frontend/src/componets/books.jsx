import React, { useState, useEffect } from 'react';
import { useRef } from 'react';
import axios from 'axios';
import { Container, Accordion, Card, Button, Row, Col, Alert } from 'react-bootstrap'
import './assets/styles.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import AddBooks from './addBooks';
import Popup from 'reactjs-popup';
import GetBooksById from './GetBooksById';

function Books() {

    const [books, setBooks] = useState([]);



    useEffect(() => {
        getBooks()
    }, [])


    const [deleteResult, setDeleteResult] = useState(null);

    const fortmatResponse = (res) => {
        return JSON.stringify(res, null, 2);
    };


    const getBooks = async () => {
        const { data } = await axios.get("https://localhost:44316/api/Books")
        setBooks(data.books);
    }

    const deleteById = async (id) => {

        if (id) {
            try {

                const res = await axios.delete(`https://localhost:44316/api/Books/DeleteBook/${id}`)

                const result = {
                    data: res.data
                }
                //

                setDeleteResult(fortmatResponse(result));
            } catch (error) {
                setDeleteResult(fortmatResponse(error.response?.data || error))
            }
        }


    }
    return (
        <Container>

            {books.length > 0 ? (<div className="section">

                {books.map((books) => (
                    <Container key={books.id}>
                        <Accordion >
                            <Accordion.Item eventKey={0}>
                                <Accordion.Header className='text-center'>{books.title}</Accordion.Header>
                                <Accordion.Body>
                                    <Card data-aos="fade-up" data-aos-offset={10} key={books.id}>
                                        <Row>
                                            <Card.Title className='text-center mt-3'>{books.title}</Card.Title>
                                            <Card.Body>
                                                <Container fluid>
                                                    <Row>
                                                        <Col lg={4} md={4} sm={12}>
                                                            <br />
                                                            <Card.Subtitle><strong>Description</strong></Card.Subtitle>
                                                            <br />
                                                            <Card.Text className="scroll">{books.description}</Card.Text>
                                                        </Col>
                                                        <Col lg={8} md={8} sm={12}>
                                                            <br />
                                                            <Card.Subtitle><strong>Excerpt</strong></Card.Subtitle>
                                                            <br />
                                                            <Card.Text className="scroll">{books.excerpt}</Card.Text>
                                                        </Col>
                                                    </Row>
                                                    <Row className='d-grid gap-2 text-center'>
                                                        <Col >
                                                            <Popup trigger={<Button variant='primary mt-3 me-2'>New Book</Button>}>
                                                                <AddBooks />
                                                            </Popup>
                                                            <Button variant='success mt-3 me-2' >Edit</Button>
                                                            <Popup trigger={<Button variant='secondary mt-3 me-2' >Search Book</Button>}>
                                                                <GetBooksById />
                                                            </Popup>

                                                            <Button variant='danger mt-3 me-2' onClick={() => deleteById(books.id)}>Delete</Button></Col>
                                                        {deleteResult && <Alert variant='success'><pre>{deleteResult}</pre></Alert>}

                                                    </Row>
                                                </Container>
                                            </Card.Body>
                                        </Row>
                                        <Card.Footer>
                                            <Row>
                                                <div className='col-6'> <Card.Text><strong>Pages:</strong> {books.pageCount}</Card.Text></div>
                                                <div className='col-6'> <Card.Text><strong>Publish date:</strong> {books.publishDate}</Card.Text></div>
                                            </Row>
                                        </Card.Footer>
                                    </Card>
                                </Accordion.Body>
                            </Accordion.Item>
                        </Accordion>
                    </Container>


                ))}
            </div>
            ) : (
                <p className='spinner'>Loading</p>
            )}




        </Container >
    );
}

export default Books;

