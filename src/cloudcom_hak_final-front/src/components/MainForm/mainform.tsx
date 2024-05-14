import '../../css/mainform.css';
import '../../css/sign.css';
import { useNavigate } from'react-router-dom';
import img1 from '../../assets/tasklist.png';
import img2 from '../../assets/mytasks.png';
import img3 from '../../assets/saloon.png';
import img4 from '../../assets/home.png';
import React, { useState } from 'react';
import '../../css/imagepanel.css';


export const MainForm = () => {
    
    const [hoverIndex, setHoverIndex] = useState<number | null>(null);
    const navigate = useNavigate();
    const gotoAllTasks = () => navigate('/alltasks');
    const gotoMyTasks = () => navigate('/mytasks');
    const gotoRating = () => navigate('/rating');
    const gotoStore = () => navigate('/store');

    return (
    <div className="mainform">
        <div className="navbar">

        </div>
    <div className="mainform-container">
        <div
        className={`image-container ${hoverIndex === 0 ? 'hover' : ''}`}
        onMouseEnter={() => setHoverIndex(0)}
        onMouseLeave={() => setHoverIndex(null)}
        >
        <img src={img1} alt="Image 1" onClick={gotoRating}/>
        <div className="text-overlay">
    <p>Рейтинг</p>
    </div>
        </div>
        <div
        className={`image-container ${hoverIndex === 1 ? 'hover' : ''}`}
        onMouseEnter={() => setHoverIndex(1)}
        onMouseLeave={() => setHoverIndex(null)}
        >
        <img src={img2} alt="Image 2" onClick={gotoMyTasks} />
        <div className="text-overlay">
    <p>Мои задания</p>
    </div>
        </div>
        <div
        className={`image-container ${hoverIndex === 2 ? 'hover' : ''}`}
        onMouseEnter={() => setHoverIndex(2)}
        onMouseLeave={() => setHoverIndex(null)}
        >
        <img src={img3} alt="Image 3"  onClick={gotoAllTasks} />
        <div className="text-overlay">
    <p>Задания</p>
    </div>
        </div>
        <div
        className={`image-container ${hoverIndex === 3 ? 'hover' : ''}`}
        onMouseEnter={() => setHoverIndex(3)}
        onMouseLeave={() => setHoverIndex(null)}
        >
        <img src={img4} alt="Image 4" onClick={gotoStore}/>
        <div className="text-overlay">
    <p>Магаз</p>
    </div>
        </div>
    </div>
    </div>
    );
    };

