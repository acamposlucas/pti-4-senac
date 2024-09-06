import React, { useContext, useEffect } from 'react';
import UserContext from '../../contexts/UserContext';
import Card from 'react-bootstrap/Card';


export function Home() {
  const { setUser } = useContext(UserContext);

  useEffect(() => {
    
    fetch('https://localhost:7168/api/Familia/{id}')
      .then(response => response.json())
      .then(data => {
        setUser(data); 
      })
      .catch(error => {
        console.error('Erro ao buscar dados:', error);
      });
  }, [setUser]); 

  return (
    <div>
      <h1>Bem-vindo!</h1>
      <MembrosCadas /> 
    </div>
  );
}



function MembrosCadas() {
  return (
    <>
      {[
        'Primary',
        'Light',
            ].map((variant) => (
        <Card
          bg={variant.toLowerCase()}
          key={variant}
          text={variant.toLowerCase() === 'light' ? 'dark' : 'white'}
          style={{ width: '18rem' }}
          className="mb-2"
        >
          <Card.Header>Membro</Card.Header>
          <Card.Body>
            <Card.Title> Nome Membro</Card.Title>
            <Card.Text>
              Idade: 
            </Card.Text>
          </Card.Body>
        </Card>
      ))}
    </>
  );
}

export default Home; 