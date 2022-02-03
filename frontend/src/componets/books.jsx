import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Table, Container } from 'react-bootstrap'



function Books() {
   
    const [books, setBooks] = useState({
        id: "",
        title: "",
        description: "",
        pageCount: "",
        excerpt: "",
        publishDate: ""
    });

    useEffect(() => {
        getBooks()
    }, [])
  
    function getBooks() {
        axios({
            method: "GET",
            url: "https://localhost:44316/api/Books",
        }).then((response) => {
            const data = response.data
            setBooks(data)
        }).catch((error) => {
            if (error.response) {
                console.log(error.response);
                console.log(error.response.status);
                console.log(error.response.headers);
            }
        })
 
    }
   
    return (
        <Container>
            <Table>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Username</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>Jacob</td>
                        <td>Thornton</td>
                        <td>@fat</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td colSpan={2}>Larry the Bird</td>
                        <td>@twitter</td>
                    </tr>
                </tbody>
            </Table>
        </Container >
    );
}

export default Books;

