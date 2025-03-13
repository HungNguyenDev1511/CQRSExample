import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './pages/Home';
import AddStudent from './pages/AddStudent';
import EditStudent from './pages/EditStudent';
import StudentDetail from './pages/StudentDetail';

const App = () => {
    return (
        <Router>
            <div>
                <h1>Student Managements</h1>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/add" element={<AddStudent />} />
                    <Route path="/edit/:id" element={<EditStudent />} />
                    <Route path="/student/:id" element={<StudentDetail />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;