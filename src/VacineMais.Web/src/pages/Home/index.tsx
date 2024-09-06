import React, { useContext, useEffect, useState } from 'react';
import UserContext from '../../contexts/UserContext';
import Card from 'react-bootstrap/Card';

export function Home() {
  const { setUser } = useContext(UserContext);
  const [membros, setMembros] = useState([]); 

  useEffect(() => {
    fetch('https://localhost:7168/api/Familia/{id}')
      .then(response => response.json())
      .then(data => {
        setUser(data);
        setMembros(data.membros);
      })
      .catch(error => {
        console.error('Erro ao buscar dados:', error);
      });
  }, [setUser]);

  return (
    <div>
      <h1>Bem-vindo!</h1>
      <MembrosCadas membros={membros} /> 
    </div>
  );
}

function MembrosCadas({ membros }) { 
  return (
    <>
      {membros.map((membro, index) => (
        <Card
          bg={index % 2 === 0 ? 'primary' : 'light'}
          key={membro.id}
          text={index % 2 === 0 ? 'white' : 'dark'}
          style={{ width: '18rem' }}
          className="mb-2"
        >
          <Card.Header>{`Membro ${membro.id}`}</Card.Header>
          <Card.Body>
            <Card.Title>{membro.nome}</Card.Title>
            <Card.Text>
             Informações
            </Card.Text>
          </Card.Body>
        </Card>
      ))}
    </>
  );
}

export default Home;
