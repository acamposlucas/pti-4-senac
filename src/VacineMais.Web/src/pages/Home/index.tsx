import React, { useContext, useEffect } from 'react';
import UserContext from '../../contexts/UserContext';
import Card from 'react-bootstrap/Card';

// Componente Home
export function Home() {
  const { setUser } = useContext(UserContext);

  useEffect(() => {
    // Substitua a URL pela URL correta da sua API
    fetch('https://localhost:7168/api/Imunizacao')
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
      <MembrosCadas /> {/* Adicione MembrosCadas aqui se necessário */}
    </div>
  );
}


// Componente MembrosCadas
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

export default Home; // Exporta Home como padrão
