import React from 'react';

const StudentCard = ({ student }) => {
    return (
        <div style={{ border: '1px solid #ddd', padding: '10px', margin: '10px', borderRadius: '5px' }}>
            <h3>{student.name}</h3>
            <p>Email: {student.email}</p>
            <p>Address: {student.address}</p>
            <p>Age: {student.age}</p>
        </div>
    );
};

export default StudentCard;