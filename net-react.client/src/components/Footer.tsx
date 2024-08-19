import React from "react";

const Footer: React.FC = () => {
    return (
        <footer>
            <div className="flex ">
                <div className="">
                    <p>Category list</p>
                    <div>
                        <a href="https://www.youtube.com" target="_blank">
                            <i className="fa-brands fa-facebook"></i>
                        </a>
                        <a href="https://www.youtube.com" target="_blank">
                            <i className="fa-brands fa-youtube"></i>
                        </a>
                        <a href="https://www.youtube.com" target="_blank">
                            <i className="fa-brands fa-linkedin"></i>
                        </a>
                        <a href="https://www.youtube.com" target="_blank">
                            <i className="fa-brands fa-instagram"></i>
                        </a>
                    </div>
                </div>
                <div className="flex">
                    <div>
                        <h2>Links</h2>
                        <p>Rules</p>
                    </div>
                    <div>
                        <h2>Contact</h2>
                        <p>Contact with us</p>
                    </div>
                </div>
            </div>
        </footer>
    );
};

export default Footer;