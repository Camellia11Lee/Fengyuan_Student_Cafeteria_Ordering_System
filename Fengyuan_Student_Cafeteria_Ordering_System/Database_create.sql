


----�������ݿ�
create database DATA;
use DATA;

----------������ر�

-- �ò��û���
CREATE TABLE �ò��û� (
    �˺� VARCHAR(30) NOT NULL,
    ���� VARCHAR(50) NOT NULL,
    ���� CHAR(50) NOT NULL,
    �ֻ��� CHAR(15) NOT NULL,
    PRIMARY KEY (�˺�)
);

-- ������Ϣ��
CREATE TABLE ������Ϣ (
    ���ں� CHAR(15) NOT NULL,
    ���� VARCHAR(50) NOT NULL,
    ������ VARCHAR(50) NOT NULL,
    PRIMARY KEY (���ں�)
);

-- ��ʳ��
CREATE TABLE ��ʳ (
    ��ʳ�� int identity(1,1) NOT NULL,
    ��ʳ���� VARCHAR(50) NOT NULL,
    ��ʳ�۸� FLOAT(5) NOT NULL,
	���� VARCHAR(1000),
	���ں� char(15),
    ����ʱ�� FLOAT(2) NOT NULL,
    PRIMARY KEY (��ʳ��),
	FOREIGN KEY (���ں�) REFERENCES ������Ϣ(���ں�)
);

-- ������
CREATE TABLE ���� (
    ������ INT IDENTITY(1,1) NOT NULL,
    ��ʳ�� int NOT NULL,
    ���ں� CHAR(15) NOT NULL,
	�˺�   VARCHAR(30) NOT NULL,
    ����ʱ�� DATETIME NOT NULL,
    �ӵ�ʱ�� DATETIME,
    ����״̬ TINYINT NOT NULL CHECK (����״̬ BETWEEN 0 AND 5),
    ���� VARCHAR(1000),
    PRIMARY KEY (������),
    FOREIGN KEY (��ʳ��) REFERENCES ��ʳ (��ʳ��),
    FOREIGN KEY (���ں�) REFERENCES ������Ϣ (���ں�),
	FOREIGN KEY (�˺�) REFERENCES �ò��û� (�˺�)

);

-- �˲ͱ�
CREATE TABLE �˲� (
    ������ INT NOT NULL,
    �۸� FLOAT(5) NOT NULL,
    ����״̬ TINYINT NOT NULL CHECK (����״̬ IN (0, 1)),
    PRIMARY KEY (������),
    FOREIGN KEY (������) REFERENCES ���� (������)
);


-- ���ò��û����������
INSERT INTO �ò��û� (�˺�, ����, ����, �ֻ���)
VALUES ('zhangsan', '123456', '����', '13800000001'),
       ('lisi', 'abcdef', '����', '13900000002'),
       ('wangwu', '888888', '����', '13700000003');

-- �򴰿���Ϣ���������
INSERT INTO ������Ϣ (���ں�, ����, ������)
VALUES('C1','123','ը������'), 
('A01', '111111', 'һ¥һ�Ŵ���'),
('A02', '222222', 'һ¥���Ŵ���'),
('B01', '333333', '��¥һ�Ŵ���');

-- ���ʳ���������

INSERT INTO ��ʳ (��ʳ����, ����, ��ʳ�۸�,���ں�,����ʱ��) VALUES
( '����', '̽�������ļ�����ζ��ÿһ�ڶ��Ƕ��ص���ʳ���飬��������ʳ�ĺʹ�ͳ���գ��������������������ջ��С�',14,'C1',12),
( '���ּ���', '�ڸ���࣬�������ۣ��������ղ��ܵ����ּ��ȣ���ζ�ջ�һ�ھͰ��ϡ�', 3,'C1',3),
( '���Ƽ��ȱ�', '���㼦�ȣ���Ƥ�������ƽ��ϣ����Ƽ��ȱ���һ��ҧ�£�����������ζ��', 8,'C1',6);

-- �򶩵����������
INSERT into ���� (��ʳ��, ���ں�,�˺�, ����ʱ��, �ӵ�ʱ��, ����״̬)
VALUES (1, 'A01', 'zhangsan','2021-10-01 12:00:00', '2021-10-01 12:05:00', 3),
       (2, 'A02', 'lisi','2021-10-01 12:10:00', '2021-10-01 12:15:00', 4),
       (3, 'B01','wangwu', '2021-10-01 12:20:00', NULL, 1);

-- ���˲ͱ��������
INSERT INTO �˲� (������, �۸�, ����״̬)
VALUES (3, 20.00, 0);